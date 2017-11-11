# Challenge
You are required to write a program which accepts a user location as a pair of co-
ordinates, and returns a list of the five closest events, along with the cheapest ticket
price for each event.

## Usage
- Inside the project folder, run the .exe file
- Alternatively, Load the project into Visual Studio, build and run the project
- Once run, the output of the seed data can be viewed in a file called "Generated Seed Data.txt"

## Assumptions
- There will only ever be between 10 and 30 events
- There will only ever be between 0 and 100 tickets available for each event
- Prices of tickets range from 10 to 300 dollars
- The program will only display the nearest five events to the user. This could mean that other events with the same distance are ignored.

#### How might you change your program if you needed to support multiple events at the same location?
The program would need to be changed to display multiple results for events at the same location. Alternatively, the program could take the cheapest ticket of all events at the same location and only include that event in the closest events to the user.

#### How would you change your program if you were working with a much larger world size?
A database would be required if dealing with a larger dataset. For the purpose of this project, Collections were fine, but with a much larger dataset, a database would ensure that all events are stored and could be queried easier. This would also help with performance if the dataset was very large as the indexing and advanced queries could be used.
