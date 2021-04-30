# FinalYearProject

Kyle Heffernan's Final Year Project Repo.


# CoviSim

The purpose of this project is to simulate the environment of a populated office. The program starts off on a screen that allows the user to adjust certain variables which will affect the result.

Once the simulation is started, autonomous agents enter the building representing workers going about their daily work shift. The building has a navigation mesh which is utilised by the agents so they can path find through the office. At the start of the simulation, each agent goes to their respective desk, which is chosen at random at the start and begins working. Agents will intermittently do various tasks such as retrieving a file or printing something off and then return to their desks. This is due to each of the agents having a behaviour tree, so they have a set of tasks that they switch between.

One of the agents is infected with COVID-19 and is continuously spreading it throughout the office as the day goes on via a particle system that emulates breathing. The virus is spread by the particles emit, which can contaminate a surface or expose an agent if they collide with it. Agents also have a chance of becoming exposed if they touch another exposed agent or if they touch a contaminated surface. The chances of an agent becoming exposed when they come in contact with an infectious particle are affected by what the user selected at the start of the simulation, and the figures used in these calculations are taken from a WHO backed study.

As the simulation runs, the user can walk around the office to get a better view of the virus spreading, or they can look through the office security cameras. The user is also able to change the rate at which time passes, so they could have the simulation run at times ten-speed to see the results faster.

Once the working hours set by the user have ended, the agents begin to leave the office. Once they all leave, a screen is displayed to the user with statistics from the simulation that was just run, and the user has the option to run the simulation again with different options.

If you download and try out this project, there is a short google form with some questions about your experience and it would be greatly appreciated if you could fill it out:

https://forms.gle/e6uxvRCRyjezA1sa9

# Itch.io
https://kyleheffernan.itch.io/covisim