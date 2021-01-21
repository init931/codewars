using System;
namespace CodeWarsSharp.Principles {
    public class LiskovSubstitutionPrinciple {
        /// <summary>
        /// Not following the Liskov Substitution Principle  
        /// </summary>
        public class ViolatePrinciple {
            public ViolatePrinciple() {
                //Calling class not following Liskov Substitution Principle  

                AccessDataFile accessDataFile = new AdminDataFileUser();
                accessDataFile.FilePath = @"c:\temp\a.txt";
                accessDataFile.ReadFile();
                accessDataFile.WriteFile();

                AccessDataFile accessDataFileR = new RegularDataFileUser();
                accessDataFileR.FilePath = @"c:\temp\a.txt";
                accessDataFileR.ReadFile();
                accessDataFileR.WriteFile();  // Throws exception  
            }

            public class AccessDataFile {
                public string FilePath { get; set; }
                public virtual void ReadFile() {
                    // Read File logic  
                    Console.WriteLine($"Base File {FilePath} has been read");
                }
                public virtual void WriteFile() {
                    //Write File Logic  
                    Console.WriteLine($"Base File {FilePath} has been written");
                }
            }

            public class AdminDataFileUser : AccessDataFile {
                public override void ReadFile() {
                    // Read File logic  
                    Console.WriteLine($"File {FilePath} has been read");
                }

                public override void WriteFile() {
                    //Write File Logic  
                    Console.WriteLine($"File {FilePath} has been written");
                }
            }


            public class RegularDataFileUser : AccessDataFile {
                public override void ReadFile() {
                    // Read File logic  
                    Console.WriteLine($"File {FilePath} has been read");
                }

                public override void WriteFile() {
                    //Write File Logic  
                    throw new NotImplementedException();
                }
            }
        }

        public class FollowPrinciple {
            public FollowPrinciple() {
                IFileReader fileReader = new AdminDataFileUserFixed();
                fileReader.ReadFile(@"c:\temp\a.txt");

                IFileWriter fileWriter = new AdminDataFileUserFixed();
                fileWriter.WriteFile(@"c:\temp\a.txt");

                IFileReader fileReaderR = new RegularDataFileUserFixed();
                fileReaderR.ReadFile(@"c:\temp\a.txt");
            }

            public interface IFileReader {
                void ReadFile(string filePath);
            }

            public interface IFileWriter {
                void WriteFile(string filePath);
            }

            public class AdminDataFileUserFixed : IFileReader, IFileWriter {
                public void ReadFile(string filePath) {
                    // Read File logic    
                    Console.WriteLine($"File {filePath} has been read");
                }

                public void WriteFile(string filePath) {
                    //Write File Logic    
                    Console.WriteLine($"File {filePath} has been written");
                }
            }

            public class RegularDataFileUserFixed : IFileReader {
                public void ReadFile(string filePath) {
                    // Read File logic    
                    Console.WriteLine($"File {filePath} has been read");
                }
            }
        }
    }
}
