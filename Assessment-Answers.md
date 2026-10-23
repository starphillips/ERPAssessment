## Task 1: Decide where this validation should live

I decided the validation should live where the variables are set within the class. This is so when other users check what the Employee class consists of, they will see the conditions required to create their own object and avoid any invalid entries.


## Task 2: Add Update and Delete
200 – returned when the request is successful.

At 200, for PUT I return the employee who has been edited with their updated details. For DELETE I return the employee who has been deleted. This is so the user has confirmation of the changes made.

204 – when the request is successful, but there is nothing to return.
In this instance I do not use a 204 return because I think in both cases something should be visible to the user for confirmation.

400 – when the request is invalid.

An error will be returned. I use the system’s standard error as it should be able to identify what in the request is invalid.

404 – when an employee with the given ID does not exist, or the URL or endpoint doesn’t exist.

When an employee with the given ID does not exist, the controller returns NotFound(). 404 also returns the system error when the endpoint or URL doesn’t exist.

## Task 3: OOP

I used the abstraction OOP principle because a user should have a specific type either Permanent or Contract, therefore should no longer be able to use the Employee class to create an employee.

This ensures every created employee will still inherit the same properties from the Employee class, but each child class performs a different calculation for CalculatePay(), depending on the Employee type, using Polymorphism.

