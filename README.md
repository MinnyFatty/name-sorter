***The Goal: Name Sorter***

Build a name sorter. Given a set of names, order that set first by last name, then by any given names the person may have. A name must have at least 1 given name
and may have up to 3 given names.

*Example Usage*

Given a a file called unsorted-names-list.txt containing the following list of names;


Janet Parsons

Vaughn Lewis

Adonis Julius Archer

Shelby Nathan Yoder

Marin Alvarez

London Lindsey

Beau Tristan Bentley

Leo Gardner

Hunter Uriah Mathew Clarke

Mikayla Lopez

Frankie Conner Ritter


**Executing the program in the following way;
name-sorter ./unsorted-names-list.txt**


*Should result the sorted names to screen;*

Marin Alvarez

Adonis Julius Archer

Beau Tristan Bentley

Hunter Uriah Mathew Clarke

Leo Gardner

Vaughn Lewis

London Lindsey

Mikayla Lopez

Janet Parsons

Frankie Conner Ritter

Shelby Nathan Yoder


*and a file in the working directory called sorted-names-list.txt containing the sorted names.*

**Assessment Criteria**

We will execute your submission against a list with a thousand names.


**Logic Followed below:**

-clean input list - remove multiple spaces by replacing double space with single space

-assign id for post sort display

-get last value from input and assign as column surname

-note - check for max names =3

-concatenate all words with surname first or used .OrderBy 

-sort alphabetically

-add to list and using display id in point 2 to display names in order 

-write to output
