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
git clone https://github.com/mburaozkan/ML-Agents-PPO-Target-Navigation.git
cd ML-Agents-PPO-Target-Navigation
```

### 3. Set up Unity project

Open the Unity project located in this repository. After cloning, you can directly use the provided Unity project as your working environment.

1. Open Unity Hub and select the `ML-Agents-PPO-Target-Navigation` project.
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
  venv\Scripts\activate
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
  
  ```bash
  pip install mlagents
  ```

2. Install PyTorch (and its associated libraries):
    
  ```bash
  pip install torch torchvision torchaudio
  ```

3. Install the specific version of protobuf to avoid conflicts:
  
  ```bash
  pip install protobuf==3.20.3
  ```

### 7. Verify ML-Agents installation

To confirm that ML-Agents has been installed correctly, run the following command to check the available options:

```bash
mlagents-learn -h
```

or 

```bash
mlagents-learn --help
```

This should display a list of available commands and options for ML-Agents.

### 8. Start Training

After verifying the installation, you can start the training process. Run the following command to initialize training:

```bash
mlagents-learn --run-id=Test1
```

When the terminal prompts you to start the Unity environment, go to Unity and press the **Play** button in the Unity Editor. The agent will begin training in the scene, and you can observe its progress in real-time.

Training results, including the trained model, will be saved in a `results/Test1` folder.

### 9. Results

After the training is complete, you can view the training progress and metrics using **TensorBoard**. Follow these steps to open TensorBoard and analyze the results:

#### Step 1: Install TensorBoard
If you don’t have TensorBoard installed, run:


```bash
pip install tensorboard
```

#### Step 2: Open TensorBoard
Navigate to the folder where the results were saved. This will be in the `results/Test1` folder. To open TensorBoard and monitor the training, use the following command:

```bash
tensorboard --logdir=results/Test1
```

This will start a local server where you can visualize the training progress. Open a browser and go to the address displayed in the terminal (typically `http://localhost:6006`).

#### Step 3: View the Metrics
TensorBoard will display various metrics, such as rewards, losses, and episode lengths. You can use these graphs to evaluate how well the agent is learning over time.

#### Step 4: Access the Results Folder
Inside the `results/Test1` folder, you will find:
- The saved **ONNX** model file, which you can use to deploy the agent.
- Logs for the training process, which can be used to analyze or continue training.

Here’s an example of what the results folder structure might look like:

![Results Folder Example](path_to_your_image.png)
