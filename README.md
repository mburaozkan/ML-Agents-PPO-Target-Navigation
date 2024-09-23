# ML-Agents PPO Target Navigation

This repository contains a Unity ML-Agents project where an agent is trained using **Proximal Policy Optimization (PPO)** to autonomously navigate to a target point in a 2D environment. The training process is done using Unity's ML-Agents toolkit.

![Training Instance](path_to_your_gif.gif)

## Features

- **ML-Agents**: Implements Unity's ML-Agents toolkit for agent-based learning.
- **PPO Algorithm**: Proximal Policy Optimization (PPO) is used to train the agent.
- **Target Navigation**: The agent learns to navigate to a specified target point.

## Installation

### 1. Install Python 3.9.13

Make sure you have Python 3.9.13 installed. You can download it from [here](https://www.python.org/downloads/release/python-3913/).

### 2. Clone the repository

```bash
git clone [https://github.com/your-username/ml-agents-ppo-target-navigation.git](https://github.com/mburaozkan/ML-Agents-PPO-Target-Navigation.git)
cd ml-agents-ppo-target-navigation
```

### 3. Set up Unity project

Open the Unity project located in this repository. After cloning, you can directly use the provided Unity project as your working environment.

1. Open Unity Hub and select the `ml-agents-ppo-target-navigation` project.
2. Ensure that ML-Agents is set up correctly in Unity.
3. The project was developed using **Unity Editor version 2021.3.22f1**. Make sure you are using this version or a compatible one to avoid issues.
4. The training environment is set up in a 2D scene provided within the project.

### 4. Create and activate a virtual environment

Navigate to the project folder and run the following commands to set up your environment:

To create a virtual environment:
  
```bash
python -m venv venv
```

Activate the virtual environment:

- On Windows:
  ```bash
  venv\Scripts\activate`
  ```
  
- On macOS/Linux:
  ```bash
  source venv/bin/activate
  ```
### 5. Upgrade pip

Once the virtual environment is activated, upgrade `pip` to the latest version by running the following command:

```bash
python -m pip install --upgrade pip
```

### 6. Install dependencies

Once `pip` is upgraded, install the required dependencies by running the following commands:

1. Install ML-Agents:
  
   `pip install mlagents`

2. Install PyTorch (and its associated libraries):
  
   `pip install torch torchvision torchaudio`

3. Install the specific version of protobuf to avoid conflicts:

   `pip install protobuf==3.20.3`

### 7. Verify ML-Agents installation

To confirm that ML-Agents has been installed correctly, run the following command to check the available options:

`mlagents-learn -h`

or 

`mlagents-learn --help`

This should display a list of available commands and options for ML-Agents.

### 8. Start Training

After verifying the installation, you can start the training process. Run the following command to initialize training:

`mlagents-learn --run-id=Test1`

When the terminal prompts you to start the Unity environment, go to Unity and press the **Play** button in the Unity Editor. The agent will begin training in the scene, and you can observe its progress in real-time.

Training results, including the trained model, will be saved in a `results/Test1` folder.

### Results

Below is a demo GIF of the training process:

![Training Demo](path_to_your_gif.gif)
