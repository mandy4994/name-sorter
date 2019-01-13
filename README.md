# name-sorter

### Project Background
GlobalX coding test - Build a name sorter. Given a set of names, order that set first by last name, then by any given names the person may have. A
name must have at least 1 given name and may have up to 3 given names.

### Prerequisites
This project is built using:
- Visual Studio 2017
- Dot Net Core 2.1

### Project Architecture and its Responsibility
It is n-tired architecture and each layer have single purpose. Each layer has single responsibility. The framework is highly cohesive and loosely coupled. Each layer just interacts with one another layer except cross cutting concerns and dependency injection module.
The following is project layout:

| Projects | Purpose |
|----------|---------|
| name-sorter |This is the entry point app project |
| name-sorter.tests | The Unit tests of name-sorter resides here |
| name-sorter.UI | The purpose of this layer is to separate out UI functionality |
| name-sorter.Common | This is a **cross cutting concern** and its used accross the layer. All content management is done here. |
| name-sorter.Data | The responsibility of this project is to perform data operations (like reading data and writing data to the file) |
| name-sorter.Data.Tests | The Unit tests of name-sorter.Data resides here |
