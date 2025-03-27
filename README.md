# ToDoApi

**ToDoApi** is a RESTful API built with .NET that allows users to manage to-do lists and tasks. It also integrates with external services to provide information about music, weather, holidays, and random facts.

## Features
- **Task List Management**: Create, view, update, and delete task lists.
- **Task Management**: Add tasks to lists, view task details, update task status, and delete tasks.
- **External Service Integrations**:
  - **Music**: Retrieve music track information and find music URIs.
  - **Weather**: Get current weather details.
  - **Holidays**: Get information about upcoming holidays.
  - **Random Facts**: Fetch random facts for entertainment.

## API Endpoints

| Endpoint                         | Method | Description                     |
|----------------------------------|--------|---------------------------------|
| `/api/todolists`                 | GET    | Retrieve all to-do lists        |
| `/api/todolists/{id}`            | GET    | Retrieve a specific list        |
| `/api/todolists`                 | POST   | Create a new to-do list         |
| `/api/todolists/{id}`            | PUT    | Update an existing list         |
| `/api/todolists/{id}`            | DELETE | Delete a list                   |
| `/api/todolists/{listId}/tasks`  | GET    | Retrieve all tasks in a list    |
| `/api/tasks/{id}`                | GET    | Retrieve a specific task        |
| `/api/todolists/{listId}/tasks`  | POST   | Add a new task to a list        |
| `/api/tasks/{id}`                | PUT    | Update an existing task         |
| `/api/tasks/{id}`                | DELETE | Delete a task                   |
| `/api/music/{trackId}`           | GET    | Retrieve music track information|
| `/api/weather`                   | GET    | Retrieve current weather details|
| `/api/holidays`                  | GET    | Retrieve upcoming holidays      |
| `/api/randomfact`                | GET    | Retrieve a random fact          |

## Project Structure

- **ToDoListApi**: The main API project containing controllers, models, and services.
  - **Controllers**: Contains various controllers managing different integrations:
    - `DBController.cs`: Manages database interactions.
    - `HolidayInfoController.cs`: Handles holiday-related functionality.
    - `RandomFactController.cs`: Retrieves random facts.
    - `TrackOfDayController.cs`: Deals with daily music tracks.
    - `WeatherController.cs`: Manages weather-related data.
  - **Models**: Contains models that represent data for various services:
    - `DBModel.cs`: Handles database-related data models.
    - `HolidayModel.cs`: Represents holiday-related data.
    - `MusicUriModel.cs`: Represents music URI-related data.
    - `RandomFactModel.cs`: Represents random fact-related data.
    - `TrackOfDayModel.cs`: Represents data related to the track of the day.
    - `WeatherModel.cs`: Represents weather-related data.
  - **Clients**: Contains client classes for external services like music, weather, and facts.
