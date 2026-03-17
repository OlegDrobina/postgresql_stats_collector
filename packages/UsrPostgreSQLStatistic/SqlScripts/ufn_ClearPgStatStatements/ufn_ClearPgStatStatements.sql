CREATE OR REPLACE FUNCTION public."ufn_ClearPgStatStatements"()
RETURNS void
LANGUAGE sql
AS $$
    SELECT pg_stat_statements_reset();
$$;