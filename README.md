# Band Tracker

#### By _**Nicole Sanders**_

## Description
This website lets the user view bands and the venues that they are playing at as well as venues with bands that have played there.

## Setup/Installation Requirements

#### Create Databases
* In SQL
\>CREATE DATABASE band_tracker
\>GO
\>USE band_tracker
\>GO
\>CREATE TABLE venues (id INT IDENTITY(1,1), name VARCHAR(255));
\>GO
\>CREATE TABLE bands (id INT IDENTITY(1,1), name VARCHAR(255));
\>GO
\>CREATE TABLE band_venue (id INT IDENTITY(1,1), band_id INT, venue_id INT);
\>GO
* Requires DNU, DNX, MSSQL, and Mono
* Clone to local machine
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

## Specifications

### Band Class
**The GetAll() method for the Band class will return an empty list if there are no entries in the Band table.**
* Example Input: N/A
* Example Output: Empty list

**The Equals method for the Band class will return true if the Band in local memory matches the Band pulled from the database.**
* Example Input:  
        > Local: "The Beatles", id is 10  
        > Database: "The Beatles", id is 10  
* Example Output: `true`

**The Save method for the Band class will save new Bands to the database.**
* Example Input:  
\> New band: "The Beatles"
* Example Output: no return value

**The Save method for the Band class will assign an id to each new instance of the Band class.**
* Example Input:  
\> New band: "The Beatles", `local id: 0`  
* Example Output:  
\> "The Beatles", `database-assigned id`  

**The GetAll() method for the Band class will return a list of all the bands in the band table.**
* Example Input:
\> New band: "The Beatles"
\> New band: "Madonna"
* Example Output: {The Beatles}, {Madonna}

**The Find method for the Band class will return the Band as defined in the database.**
* Example Input: "The Beatles"
* Example Output: "The Beatles", `database-assigned id`

**The GetVenues method for the Band class will return all the venues the specific band has played in.**
* Example Input:
        > "Fifth Avenue Theater", id is 10  
        > "Madison Square Garden", id is 11  
* Example Output: `{Fifth Avenue Theater}, {Madison Square Garden}`


### Venue Class
**The GetAll() method for the Venue class will return an empty list if there are no entries in the Venue table.**
* Example Input: N/A
* Example Output: Empty list

**The Equals method for the Venue class will return true if the Venue in local memory matches the Venue pulled from the database.**
* Example Input:  
        > Local: "Madison Square Garden", id is 10  
        > Database: "Madison Square Garden", id is 10  
* Example Output: `true`

**The Save method for the Venue class will save new Venues to the database.**
* Example Input:  
\> New venue: "Madison Square Garden"
* Example Output: no return value

**The Save method for the Venue class will assign an id to each new instance of the Venue class.**
* Example Input:  
\> New venue: "Madison Square Garden", `local id: 0`  
* Example Output:  
\> "The Beatles", `database-assigned id`  

**The Find method for the Venue class will return the Venues as defined in the database.**
* Example Input: "Madison Square Garden"
* Example Output: "Madison Square Garden", `database-assigned id`

**The GetBands method for the Venue class will return all the bands that have played at that .**
* Example Input:
        > "The Beatles", id is 10  
        > "Madonna", id is 11  
* Example Output: `{The Beatles}, {Madonna}`

**The Delete method for the Venue class will Delete the venue's row in the venue table.**
* Example Input: *click delete button* Fifth avenue theater
* Example Output: nothing

**The Update method for the Venue class will Update the venue's name in the venue table.**
* Example Input: *click update button* Sixth avenue theater
* Example Output: nothing


## Support and contact details

Please contact Nicole Sanders at nsanders9022@gmail.com with any questions, concerns, or suggestions.

## Technologies Used

This web application uses:
* Nancy
* Mono
* DNVM
* C#
* Razor
* MSSQL & SSMS

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Nicole Sanders_**
