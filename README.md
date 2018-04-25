# MyoGame
### Author: Qi Fu
### Modeul: Gesture Based UI Development
* Lecturer: Dr Damien Costello

Language
> C#

Tools
> Unity 3D

> Myo Armbands
* Download and install [Myo Connect](https://www.myo.com/start)
* [Set myo under unity 3D](http://developerblog.myo.com/setting-myo-package-unity/)

> Video Link:[Here](https://youtu.be/JNbz1E8cD7o)
### Information
#### Purpose of the application and identify hardware
> This a single 3D computer game that can use Myo armbands to control character moves and keyboard to attack.
> Users find the MyoGame.exe and click it to run.
> Identify way
* Go forward -> fist
* Turn left -> wave in
* Turn right -> wave out
* Go back -> spare fingers
* Attack -> double tap


#### Architecture
> This application formal design be built by constructing game objects, and C# scripts are binding with them on the background.
> Myo object bingding a "move.cs" file to transfer the command between armbands and program functions.
![alt text](https://user-images.githubusercontent.com/24989456/38522828-aea292be-3c41-11e8-8860-a96810d5e0e7.png)

> Game Objects
* Myo prefabs
>> Finding the myo controller object and draging it into the game sence.
![alt text](https://user-images.githubusercontent.com/24989456/39153714-d31c3a2a-4743-11e8-951c-6d457d38c777.png)

>> Creating a C# script and binding relative attributes with game object "Player".
![alt text](https://user-images.githubusercontent.com/24989456/39153742-f05b8d8e-4743-11e8-914d-c9f9e5868a0d.png)

> Controller Scripts
* A pices of code 
![alt text](https://user-images.githubusercontent.com/24989456/38523360-242a387e-3c43-11e8-8cda-cd8088f519a3.png)


#### Conclusions & Recommendations
> It is a basic role playing game with myo armbands device, it allows move actions temporarily. The advanced application should allows character attack command can be identify when using other gesture actions.  
