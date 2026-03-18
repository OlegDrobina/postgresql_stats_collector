# PostgreSQL statistics collector

## Requirements:
1. .NET Framework platform.
2. 8.3.2+ application version.
3. Any build (like sales-enterprise-marketing-service-enterprise, studio, etc).
4. DBMS: PostgreSQL.


PostgreSQL statistics collector is a composable application that can be installed in MS SQL, but won't provide any useful functionality.

## Additional prerequirements

You should have pg_stat_statements specified in the shared_preload_libraries in the PostgreSQL server. Ideally it should be already registered in your database, but the utility will check if the pg_stat_statements exists and try creating it if it's not created yet. In addition your Creation application database user (the one that is used in the ConnectionStrings.config) should have either the ***superuser*** role or the ***pg_read_all_stats*** role to read data from pg_stat_statements view (but in this case the utility won't be able to register pg_stat_statements view in the database).

## List of installed content

1. The "Statistics collect tasks" section will be created in the "My applications" workspace. You can also add this section to any other workspace.
2. The "Statistics collect type" and "Statistics collector task status" lookups will be created in the "Lookups" section of the application.
3. The "Statistics collect tasks" business process will be created in the system.
4. Two functions will be registered in the Creatio database: "ufn_ClearPgStatStatements" and "
ufn_CollectPgStatStatements".
5. DCM info will be created for the "Statistics collect tasks" section.
6. "Statistics collector parameters" object and modal page for this object will be created.

## General description of utility workflow

1. The starting point of the utility is in the "Statistics collect task" section where a new task can be created by clicking the "Create a task" button.
2. The button opens the modal page where the user can specify parameters for the task to trigger. Start and end date/time fields have validators that check:
   1. If the start date/time and end date/time are not in the past (compared to the current date/time).
   2. If the start date/time is not greater than the end date/time.
3. There are 3 options (utility modes) available:
   1. ***Collect statistics between two specified date/times*** - user must select two date/times in the correspondent fields which stand for the start date/time to clear statistics and end date/time till which statistics will be collected.
   2. ***Clear statistics and finish collect at specified date/time*** - user must select end date/time till which statistics will be collected. Once the task is started current statistics are errased.
   3. ***Collect currently received statistics*** - collects statistics that is currently collected.
4. Once the correspondent task is triggered the "Statistics collect tasks" business process is started that actually creates a record in the "Statistics collect tasks" section.
5. The form page contains a DCM that is not clickable where the user can track the progress of the statistics collect task.
6. The form page contains the container where the user can review parameters that were used to trigger the task.
7. In case the task completes with an error - the status of the task will be changed to the correspondent "Error" status and also the user will see the error description in the "Error details" area that will be displayed in case the task is in the "Error" status.
![Error message area](/assets/ErrorStatusArea.png)
Also the user is informed about the status of the task in the main working area in the "Results" tab with different messages:
![Statistics collect task is in progress](/assets/CollectTaskIsInProgress.png)
8. In addition the user can see the instance of the "Statistics collect tasks" business process in the task form page:
![Business process instance. It's clickable](/assets/BusinessProcessInstance.png)
9. The result will be displayed as two expandable lists added to the task form page. One list contains top 20 most heavies requests (requests ordered by total_exec_time) and another list contains top 20 most called requests (requests ordered by calls). You cannot change sorting in both lists.

## Current improvements in progress

As of now development of the archivator that will archive old statistics collector tasks is in progress in a dedicated branch of this repository. The idea is to store old (older than 90 days) statistics collector tasks and collected data in the archive (a separate section created) and remove data completely after another 90 days. 

## Improvements and support

For additional improvements and bug fixes you can report an issue in the [`GitHub repository`](https://github.com/OlegDrobina/postgresql_stats_collector) or reach me at <o.drobina@creatio.com>.