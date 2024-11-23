# StupidException

[![Stars](https://img.shields.io/github/stars/SteConte97/StupidException)](https://github.com/SteConte97/StupidException/stargazers)  

A simple and lightweight C# library to handle exceptions with a very important feature!.

## 🚀 Key Features

In addition to the basic exception, it generates:
- A silly image of a cat (https://http.cat/);
- A random life advice (https://api.adviceslip.com/);


## 📦 Installation

Add **StupidException** to your project using [NuGet]([https://www.nuget.org/](https://www.nuget.org/packages/StupidException/)):

```bash
dotnet add package StupidException
```

Alternatively, clone the repository directly:

```bash
git clone https://github.com/SteConte97/StupidException.git
```

## 💻 Usage Example

Here is a practical example of using the library:

```csharp
using CustomStupidException;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            throw new StupidException("Something went wrong!");
        }
        catch (StupidException ex)
        {
            Console.WriteLine($"Caught an error: {ex.Message}");
        }
    }
}
```

## 🛠 Contributing

Contributions are always welcome! Follow these steps to contribute:

1. Fork the repository.
2. Create a new branch for your feature (`git checkout -b feature/NewFeature`).
3. Make your changes and commit them (`git commit -m "Add new feature"`).
4. Push the branch to your fork (`git push origin feature/NewFeature`).
5. Open a pull request on GitHub.

---

⭐️ If you find this project funny, consider giving it a **star** on GitHub!
