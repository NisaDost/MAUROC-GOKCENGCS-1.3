# ROSNode

Edit `ros2cs.spec` to include ROS 2 interface packages you wish to use.

Install `ros2cs` utility with the following command if not yet installed:
```
dotnet tool install -g ros2cs
```
After installation, simply run `ros2cs` in the project root to generate messages.

This project can also be built as a colcon package. Feel free to modify `package.xml`
and `CMakeLists.txt` to specify package dependencies and add other resources
you would like to include in the package.

See https://github.com/noelex/rclnet for more information.

--

# Custom Information

All necessary info from: https://github.com/noelex/rclnet

Creating and running nodes:
---------------------------
1- Go to "Nodes" folder and create a new folder and name it (example_node).
2- Open Developer Command Prompt (DCP) and locate to example_node directory
3- Run "dotnet new ros2-node" on DCP. This will create a node. 
4- Source ROS2 on DCP:
	call C:\dev\ros2_humble\local_setup.bat
5- Run "ros2cs" on DCP. This will import necessary interfaces.
6- Go to "Interfaces" folder and DELETE "Rosbag2StorageMcapTestdata" folder manually.
7- Source  RTI Connext  on DCP if necessary:
	call "C:\Program Files\rti_connext_dds-7.3.0\resource\scripts\rtisetenv_x64Win64VS2017.bat"
8- Run "dotnet run" on DCP, while being in the node directory.

//Do not forget to add "Interfaces" namespace in every node. (no need since we only use one node.)

Node Referencing:
---------------------------
using target_uav_id_publisher; // Ensure your custom message namespace is used

