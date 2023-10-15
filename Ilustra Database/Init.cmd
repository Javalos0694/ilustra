sqlcmd -Q "create login [Ilustra] with password = 'Ilustra2022!', CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF"
sqlcmd -Q "exec sp_addsrvrolemember [Ilustra], 'sysadmin'"

sqlcmd -Q "CREATE DATABASE Ilustra"
call Flyway/flyway -configFiles=Ilustra/flyway.conf baseline -baselineVersion=0.0
