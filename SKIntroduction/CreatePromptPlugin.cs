using Microsoft.SemanticKernel;

namespace SKIntroduction;

public static class CreatePromptPlugin
{
    public static KernelPlugin CreatePromptPluginWithFunctions(Kernel kernel)
    {
        var spellingFunction = KernelFunctionFactory.CreateFromPrompt(
             "Correct any misspelling or gramatical errors provided in input: {{$input}}",
              functionName: "spellChecker",
              description: "Correct the spelling for the user input.");

        var summarizeFunction = KernelFunctionFactory.CreateFromPrompt(
             "Summarize the provided input: {{$input}}",
              functionName: "summarizer",
              description: "summarize the user input.");

        var jokeFunction = KernelFunctionFactory.CreateFromPrompt(
             "Make a joke on the provided input: {{$input}}",
              functionName: "JokeMaker",
              description: "Make a joke on the user input.");

        var translatorFunction = KernelFunctionFactory.CreateFromPrompt(
             "Translate to english the provided input: {{$input}}",
              functionName: "translator",
              description: "translate to english the user input.");


        KernelPlugin simplePlugin =
            KernelPluginFactory.CreateFromFunctions(
                "SimpleNLPPlugin",
                "Provides some simple abilities, spelling checker, summarize, joke and translator.",
                new[] {
                    spellingFunction,
                    summarizeFunction,
                    jokeFunction,
                    translatorFunction
                });

        return simplePlugin;
    }

}
