# Minefield Game

## Overview

The Minefield game is a console application developed in C# using .NET 8. In this game, players navigate a grid while avoiding hidden mines. The objective is to reach the opposite side of the board with as few moves as possible. Players have a limited number of lives and can lose them by hitting mines. The game features multiple difficulty levels that affect the size of the grid and the number of mines.

## Features

- **Dynamic Difficulty Levels**: Choose between easy, medium, and hard difficulty settings that determine the grid size and mine count.
- **Player Lives**: Players start with three lives and lose one each time they hit a mine.
- **Score Tracking**: The game keeps track of the number of moves taken to reach the end.
- **User Input Handling**: Players can navigate the grid using W, A, S, D keys.
- **Automated Unit Testing**: The application includes unit tests written with xUnit to ensure code reliability and correctness.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A compatible IDE or text editor (e.g., Visual Studio, Visual Studio Code)

### Installation

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd MinefieldGame
