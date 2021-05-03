# project-euler
My Project Euler solutions

## About Project Euler

https://projecteuler.net/

# TODO
- Implement problem solutions
    - [x] #1 - 10
    - [ ] #11 - 20
    - [ ] #21 - 30
- [x] Implement problems as unit tests
- [ ] Maybe put this todo list in GitHub issue mgmt?
- [x] Organize project out of the main directory
- [ ] ~~Redo VS Code setup for .NET Core~~
- [x] Maybe just switch to VS Community Edition instead?
- [ ] Address inefficient solutions (below)


# Inefficient problem solutions

The Project Euler website claims that all the problems are designed to execute within 60 seconds on a modestly powered machine.

## Problem 12

Solution time = 25.8m. The fastest solution I've come up with has been a streamlined enumeration of triangle numbers from 1 .. n. As far as I can tell, the solution spends a lot of time calculating prime numbers. Research found that there are well known algorithms which are faster, but so far they are over my head to implement from the prose description.

Also, I don't think my algorithm is likely the best. I tried some others but everything else has been _dramatically_ slower compared to this simple version. My last thought was that, instead of enumerating triangle numbers (cheap) and factoring them (expensive), I could generate factor sets up until 500 divisors (??) then begin testing for triangle numbers (cheap). Maybe this approach would work with a smarter algorithm.

One thing I've learned from this - I seriously underestimated how difficult it would be to go from a "good basic" algorithm to a "top performing" algorithm. It wasn't worth the frustration to try to optimize now instead of revisiting it later.

