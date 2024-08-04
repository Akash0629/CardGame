## Application (use Case) Project

In Clean Architecture, the Use Cases (or Application Services) project is a relatively thin layer that wraps the domain model.

Use Cases are typically organized by feature. These may be simple CRUD operations or much more complex activities.

Use Cases should not depend directly on infrastructure concerns, making them simple to unit test in most cases.

Use Cases are often grouped into Commands and Queries, following CQRS.

Having Use Cases as a separate project can reduce the amount of logic in UI and Infrastructure projects.

