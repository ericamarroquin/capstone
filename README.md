# EMDB

## PURPOSE

"EMDB" is an application that allows a user to track the TV shows they are watching. The user will be able to enter the show name, genre, amount of episodes, and actors in the show. Users will then be presented with data on what their favorite genres are and what actors they enjoy watching. 

## MVP

1. Create "EMDB" API containing information about a users favorite shows using C# with full CRUD endpoints
2. A React front end allowing the user to browse through show entries and update them as more shows are watched
3. User authentication and authorization using auth0

## TECHNOLOGIES USED FOR MVP

- React.js
- C#/.NET5
- MySQL
- auth0

## EXTRA FEATURES

1. Allow user to view their data, a la Spotify Wrapped
  - ex: "Your top genre is: drama, you've spent x hours watching it"
2. Create a enjoyable and visually appealing user experience using Material UI

## TECHNOLOGIES FOR EXTRA FEATURES

- Material UI or Semantic UI


## DATABASE SCHEMA

See the database schema below. Shows and genre have a many-to-many relationship, where a show can have multiple genres and a genre can have multiple shows. Acting credit holds the IDs of actors and the shows that they are in. This is also many-to-many.

#### Iteration One

![preliminary database schema](https://github.com/ericamarroquin/capstone/blob/main/img/prelim_show_database.png?raw=true)

#### Iteration Two

![second database schema](https://github.com/ericamarroquin/capstone/blob/main/img/second_show_database.png?raw=true)

## API ENDPOINTS

Base URL: `http://localhost:5000`

### HTTP Requests for Shows

```
GET /api/shows
POST /api/shows
PUT /api/shows/{id}
GET /api/shows/{id}
DELETE /api/shows/{id}
```

#### Example Query

```
http://localhost:5000/api/shows/2
```

#### Path Parameters
|  Parameter   | Type   | Required | Description                     |
|  ----------- | ------ | -------- | ------------------------------- |
| name         | string | true     | Return matches by name          |

#### JSON Body for POST and PUT Requests
When querying a POST or PUT request, a JSON body is needed to add or edit information in the database, respectively. Use the following JSON body to do so.

```json
  {
    "showId": {id},
    "name": "string",
  }
```

### HTTP Requests for Actors

```
GET /api/actors
POST /api/actors
PUT /api/actors/{id}
GET /api/actors/{id}
DELETE /api/actors/{id}
```

#### Example Query

```
http://localhost:5000/api/actors/1
```

#### Path Parameters
|  Parameter   | Type   | Required | Description                     |
|  ----------- | ------ | -------- | ------------------------------- |
| name         | string | true     | Return matches by name          |

#### JSON Body for POST and PUT Requests
When querying a POST or PUT request, a JSON body is needed to add or edit information in the database, respectively. Use the following JSON body to do so.

```json
  {
    "actorId": {id},
    "name": "string",
  }
```

### HTTP Requests for Genres

```
GET /api/genres
POST /api/genres
PUT /api/genres/{id}
GET /api/genres/{id}
DELETE /api/genres/{id}
```

#### Example Query

```
http://localhost:5000/api/genres/3
```

#### Path Parameters
|  Parameter   | Type   | Required | Description                     |
|  ----------- | ------ | -------- | ------------------------------- |
| name         | string | true     | Return matches by name          |

#### JSON Body for POST and PUT Requests
When querying a POST or PUT request, a JSON body is needed to add or edit information in the database, respectively. Use the following JSON body to do so.

```json
  {
    "genreId": {id},
    "name": "string",
  }
```

## Issues

### January 2022

After taking a break from this project, I decided to do more research on lazy loading properties and why I thought they were needed. Ending this project in December, I figured out that lazy loading was the cause of my database corruption issues - it was creating a continuous loop of database queries, which I now know as the *N + 1* problem.

Lazy loading seems great, since it only loads related entries from the database when mentioned in the code, instead of loading everything first. In the code snippet of my join entity below, that's what I assumed was happening.

```cs
namespace Capstone.Models
{
  public class ActingCredit
  {
    public int ActingCreditId { get; set; }
    public int ActorId { get; set; }
    public int ShowId { get; set; }
    public virtual Actor Actor { get; set; }
    public virtual Show Show { get; set; }
  }
}
```

When I would perform a GET request for all actors that had acting credit, EF Core would fetch the actor, then go into acting credit to fetch the shows related to that actor. But, after loading the query for the acting credits, this added *another* query for the actor, starting the original request all over again. 

Right from the Microsoft docs - `Because lazy loading makes it extremely easy to inadvertently trigger the N+1 problem, it is recommended to avoid it.` 

Now I know! It for sure did create a hell of a headache, though, trying to figure out what was wrong.


## License

[MIT License](https://opensource.org/licenses/MIT)

## Contact Information

Erica Marroquin | [Email](mailto:ericamarroquin03@gmail.com) | [LinkedIn](https://www.linkedin.com/in/erica-marroquin/)