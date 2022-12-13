# Design Choices

## Asynchronous Communication

Since interplanetary communication is hard to be maitained synchronously, because of multiple factors like the time delay, and also the fact that the satellite or the rover might be in different sides of the Pluto the best way to ensure proper updates is trough the usage message queues.

Also since it is possible that the rover receives a very long set of instructions that while performing those he enters a zone with communication cover maintaining a local Db will allow to store a historical set of events that can be published into the queues as soon as the rover comes into communication range again.

## Postgres

Any relational database would do the work needed for the rover historical data. Postgres is a very well known database, the reasons I picked it was because it is free, easy to startup, and easy to scale. With it store in AWS Auraro we can even provide read replicas and have only the worker use the write database.

I avoided most noSQL database, as the requirments were not yet 100% clear on the usage and any data model would likely not be the ideial.


## API GW & 2 API's

I decided to have two different API's mainly to split the resposability of having the signalR hub in only one place avoiding the pitfall of having one API doing all the work.

The LiveFeedAPI is responsible to maintaint the signalR hub and keep an open communication with the UI to provide an always updated location of the rover.

While the Reports API provides the ability to view rover movement history and can expand to provide more reports as long as the data supports it.