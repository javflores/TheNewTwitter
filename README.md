# TheNewTwitter
Console-based social networking application (similar to Twitter)

## Main Technology stack

This application has been created using C# 6 and .Net Framework.
It uses the standard command line.

## Getting up and running:

* You need VisualStudio 2015 installed.
* After cloning this repository, just build the solution. It will get the required nuget packages.
* I have used [NCrunch](http://www.ncrunch.net/) to do TDD and run tests, but it should work with the standard Visual Studio tests explorer.
* Set the CommandLine project as start up project.
* Hit F5, the new twitter should start.

## Using The New Twitter

Currently we support the following commands:

### Posting

Publishing posts to a user's personal timeline. If user doesn't exist, it will be created.

#### Syntax

```<user name> -> <message>```

Example:

```
Alice -> I love the weather today
```

### Reading

View users timeline

#### Syntax

```<user name>```

Example:

```
Alice

I love the weather today (5 minutes ago)
```

### Following

User can subscribe to other users' timelines.

#### Syntax

```<user name> follows <another user>```

Example:

```
Charlie follows Alice
```

### Wall

View an aggregated list of user's timeline and timeline of following users.

#### Syntax

```<user name> wall```

Example:

```
Charlie wall

Charlie - I'm in New York today! Anyone want to have a coffee? (2 seconds ago)
Alice - I love the weather today (5 minutes ago)
```

Remember that <user name> must be one word

## Feedback and issues:

We really appreciate your feedback. If you want to see some improvements in the app I'll be really grateful if you can drop me an email to *javicaria@ingenieros.com*.

Additionally, if you find any issue when running the app or any other other matter, please feel free to open an issue in [this Github repo](https://github.com/javflores/TheNewTwitter/issues).

## Further improvements:

This is our MVP version of **The New Twitter**. We wanted to follow **Start small** and **Fail fast** principles so we can get your feedback as soon as possible and make changes that makes sense for you as the user of the app.

In spite of that we have considered:

* Improve managing of errors in the application and edge cases. So far we have pretty much cover the happy path.
* Managing loging.
* Persistent storage of messages.
* Having a better user interface, allowing links and posting pictures as messages.
