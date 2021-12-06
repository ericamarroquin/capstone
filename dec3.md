## Friday, 12/3

- desperately trying to figure out how to connect React and C#
- im grasping at straws here
- bridge.NET not common, on to the next one

- [this](https://alialhaddad.medium.com/build-a-basic-fullstack-app-using-c-net-core-mysql-and-webpack-react-1-3-73cfb64daeb6) looks promising, it uses all the tools we already know

- IM VERY CONFUSED

- this was in fact not helpful and now im more confused

- now im looking up using charts.js in react which feels more palpable

- shes following [this](https://blog.logrocket.com/using-chart-js-react/)
- - omg if you type `react.new` in a new browser tab it takes you to a react playground??? 

- its broken and everything is meaningless

![erica throwing computer](https://c.tenor.com/W-iD9IenPZwAAAAC/angry-panda.gif)

- react-charts is throwing so many errors and im tired

- it was a versioning error im gonna

- chart.js@2.9.4 react-chartjs-2@2.11.2

- here is the fruit of my labor: 

<img src="https://github.com/ericamarroquin/capstone/blob/main/img/nice-charts.png?raw=true" alt="graph that took really long" width="1000"/>

- the long awaited crypto graph fetching from API is COMPLETE, using the same versioning as before

<img src="https://github.com/ericamarroquin/capstone/blob/main/img/crypto-chart.png?raw=true" alt="long awaited crypto chart" width="1000"/>

## Saturday, 12/4

- Todays to-do: create a to-do list

1. Decide language, frameworks, and packages
2. Decide MVPs - what will success look like? What features can be added later?
3. Make an overview of what the project will look like - actually make a component diagram :)

## Sunday, 12/5

- Okay I talked with my programmer friend and I feel generally more capable of doing this and it makes more sense
- I'm changing my project and am no longer going to do it about crypto, because I know nothing about it and have generally no interest in it, which will add an unnecessary layer of complexity

These are the top things I want to do, my MVP:
1. Build an API with C# - full CRUD
- - Set up a local database with MySQL
2. Build out a UI with React
3. User authentication and authorization with [auth0](https://auth0.com/docs/api) - probably use their Web Application SDK

If time permits:
1. Allow user to view their data, a la Spotify Wrapped
- - Assuming based on whatever the properties of the object I create is, ex: if its an app allowing a user to store information about the TV shows they've watched, they can see "Your top genre is: drama, you've spent x hours watching it"
2. Make it look nice - I'm really focused on getting the functionality down 
