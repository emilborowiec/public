pushd migrations
if %errorlevel% neq 0 exit /b %errorlevel%

flyway clean
if %errorlevel% neq 0 exit /b %errorlevel%

flyway migrate
if %errorlevel% neq 0 exit /b %errorlevel%

popd

pushd data
if %errorlevel% neq 0 exit /b %errorlevel%

sqlite3 ntangle.db ".read import.sql"

popd