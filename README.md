# Program to Analyze Play Data
This program reads in data from a CSV file, filters it by a specific date, and then calculates the number of distinct songs played by each client. It then groups the data by the number of distinct songs played and calculates the number of clients in each group. Finally, it writes the result to a new CSV file.

## Installation and Run

1. Clone the repository to your local machine:
```bash
https://github.com/yz-baskoy/piworks-exhibit
```
2. Navigate to the project directory:
```bash
cd piworks-exhibit
```
3. Open the project in your preferred code editor and modify the filePath variable in Main method to specify the path to your input CSV file. Use / for Linux and macOS, and \ for Windows.

4. Save the changes to the file.

5. Build and run the program using the following commands:
```bash 
dotnet build
dotnet run
```
The program will read in the input data, perform the analysis, and write the output to a file named output.csv in the project directory.

## Author
[Yusuf Başköy](https://github.com/yz-baskoy/)
