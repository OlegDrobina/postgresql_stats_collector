CREATE OR REPLACE FUNCTION public."ufn_CollectPgStatStatements"(
    p_usr_task_id uuid
)
RETURNS void
LANGUAGE plpgsql
AS $$
DECLARE
    v_ext_exists boolean;
    v_preloaded boolean;
BEGIN
    --Check whether the pg_stat_statements extension exists in the current database
    SELECT EXISTS (
        SELECT 1
        FROM pg_extension
        WHERE extname = 'pg_stat_statements'
    )
    INTO v_ext_exists;

    --Create extension if missing
    IF NOT v_ext_exists THEN
        CREATE EXTENSION pg_stat_statements;
    END IF;

    --Check whether pg_stat_statements is loaded at the server level
    SELECT EXISTS (
        SELECT 1
        FROM unnest(
            string_to_array(
                coalesce(current_setting('shared_preload_libraries', true), ''),
                ','
            )
        ) AS x(lib)
        WHERE btrim(lib) = 'pg_stat_statements'
    )
    INTO v_preloaded;

    IF NOT v_preloaded THEN
        RAISE EXCEPTION
            'pg_stat_statements is not added to shared_preload_libraries. Add it and restart PostgreSQL.';
    END IF;

    --Insert filtered result to top 20 sorted by total_exec_time
    INSERT INTO "UsrPgStatStatementsTotalExecTime" (
        "UsrStatisticsCollectTaskId",
        "UsrCapturedOn",
        "UsrDatabaseName",
        "UsrTotalExecTime",
        "UsrNumberOfCalls",
        "UsrMeanExecTime",
        "UsrPercentageCPU",
        "UsrShortQuery"
    )
    SELECT
        p_usr_task_id,
        now()::text,
        pg_database.datname::text AS datname,
        round(total_exec_time::numeric, 2) AS total_exec_time,
        calls,
        round(mean_exec_time::numeric, 2) AS mean,
        round(
            (100 * total_exec_time / sum(total_exec_time::numeric) OVER ())::numeric,
            2
        ) AS percentage_cpu,
        substring(query, 1, 50000) AS short_query
    FROM pg_stat_statements
    INNER JOIN pg_database
        ON pg_database.oid = pg_stat_statements.dbid
    WHERE pg_database.datname = current_database()
    ORDER BY total_exec_time DESC
    LIMIT 20;

	--Insert filtered result to top 20 sorted by calls
	INSERT INTO "UsrPgStatStatementsCalls" (
        "UsrStatisticsCollectTaskId",
        "UsrCapturedOn",
        "UsrDatabaseName",
        "UsrTotalExecTime",
        "UsrNumberOfCalls",
        "UsrMeanExecTime",
        "UsrPercentageCPU",
        "UsrShortQuery"
    )
    SELECT
        p_usr_task_id,
        now()::text,
        pg_database.datname::text AS datname,
        round(total_exec_time::numeric, 2) AS total_exec_time,
        calls,
        round(mean_exec_time::numeric, 2) AS mean,
        round(
            (100 * total_exec_time / sum(total_exec_time::numeric) OVER ())::numeric,
            2
        ) AS percentage_cpu,
        substring(query, 1, 50000) AS short_query
    FROM pg_stat_statements
    INNER JOIN pg_database
        ON pg_database.oid = pg_stat_statements.dbid
    WHERE pg_database.datname = current_database()
    ORDER BY calls DESC
    LIMIT 20;
END;
$$;