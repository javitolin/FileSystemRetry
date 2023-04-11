# FileSystemRetry
> An IFileSystem implementation which allows simple-to-use retry functionallity with the FileSystem

## Installation
```
Install-Package FileSystemRetry
```

## Usage example
* For dependency injection you can call `services.AddRetryFileSystem()`
* You can also create your own `RetryPolicy` and send it to the function `services.AddRetryFileSystem(retryPolicy)`
* For more examples and information please consult the `SampleWorker` project or the `FileSystemRetry.Tests` project.

## Contributing
1. Fork it (<https://github.com/javitolin/FileSystemRetry/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request

## Meta

[AsadoDevCulture](https://AsadoDevCulture.com) 

[@jdorfsman](https://twitter.com/jdorfsman)

Distributed under the MIT license.