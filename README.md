WeLearn
=======

ITWorx WeLearn Club

#Migrations:
- To add a new migration:

Add-Migration -ConfigurationTypeName:RashahlyKtab.RashahlyKtabMigrations.Configuration -Name Initial

- To update the DB:

Update-Database -ConfigurationTypeName:RashahlyKtab.RashahlyKtabMigrations.Configuration
