dotnet fm migrate -p sqlserver -c "Data Source=.;Initial Catalog=ReservationSystem;User Id=sa;password=123" -a ".\src\0_Tools\ReservationSystem.DatabaseMigrations\bin\Debug\netcoreapp2.2\ReservationSystem.DatabaseMigrations.dll"