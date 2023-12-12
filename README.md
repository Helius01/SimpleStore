
# To run the program:

Navigate to Api folder:

`SimpleShop/src/Api`

Run :

`dotnet ef migration add initialDB` 

Then :

`dotnet ef database update`


Notice that if you had some issues about database connection, please check the credentional which is in `appsettings.Development.json` and replace your own Postgres connection.

Good to read:

I have no reason to using PostgreSQL in this case, i'm more comfortable with it.

I was able to use many patterns or architecture like : DDD,Repository and etc, but in this case i couldn't find any good reason to use them and i feel the current code base structure is not bad for this task.

Finally, I have to say thank you for checking it out.

Please let me know my mistakes via email:

`helius01@proton.me`