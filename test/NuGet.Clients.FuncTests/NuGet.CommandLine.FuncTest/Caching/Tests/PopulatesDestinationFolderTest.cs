using System.Threading.Tasks;
using NuGet.Test.Utility;

namespace NuGet.CommandLine.Test.Caching
{
    public class InstallsToDestinationFolderTest : ICachingTest
    {
        public string Description => "Installs the requested package to the destination folder";

        public int IterationCount => 1;

        public Task<string> PrepareTestAsync(CachingTestContext context, ICachingCommand command)
        {
            // The package is available on the source.
            context.IsPackageBAvailable = true;

            var args = command.PrepareArguments(context, context.PackageIdentityB);

            return Task.FromResult(args);
        }

        public CachingValidations Validate(CachingTestContext context, ICachingCommand command, CommandRunnerResult result)
        {
            var validations = new CachingValidations();

            validations.Add(
                CachingValidationType.CommandSucceeded,
                result.Item1 == 0);

            validations.Add(
                CachingValidationType.PackageInstalled,
                command.IsPackageInstalled(context, context.PackageIdentityB));

            return validations;
        }
    }
}
