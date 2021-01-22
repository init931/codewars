using System;
namespace CodeWarsSharp.Principles {
    public class DependencyInversionPrinciple {
        public class ViolatePrinciple {
            class MySQLConnection {
                public void connect() {
                    // handle the database connection
                }
            }

            class PasswordReminder {
                private MySQLConnection _dbConnection;

                public PasswordReminder(MySQLConnection dbConnection) { //violation
                    _dbConnection = dbConnection;
                }
            }
        }

        public class FollowPrinciple {
            interface DBConnectionInterface {
                public void connect();
            }

            class MySQLConnection : DBConnectionInterface {
                public void connect() {
                    // handle the database connection
                }
            }

            class PasswordReminder {
                private DBConnectionInterface _dbConnection;

                public PasswordReminder(DBConnectionInterface dbConnection) { //fixed
                    _dbConnection = dbConnection;
                }
            }
        }
    }
}
