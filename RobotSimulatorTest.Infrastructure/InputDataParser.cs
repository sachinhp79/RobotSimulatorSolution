using RobotSimulatorTest.Application.Interfaces;
using RobotSimulatorTest.Domain.Exceptions;

namespace RobotSimulatorTest.Infrastructure
{
    public class InputDataParser<T> : IDataParser<T> where T : class
    {
        private readonly Func<string, T> _converter;
        private static readonly char[] DefaultSeparators = new[] { ',', ';', '\n', '\r', ' ', '\t' };

        public InputDataParser(Func<string, T>? converter = null)
        {
            _converter = converter ?? DefaultConverter;
        }

        public async Task<T[]> ParseDataAsync(string data)
        {
            if (data is null) throw new DataParsingException("Invalid data, cannot parse null data" + ": " + nameof(data));

            var items = data
                .Split(DefaultSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Where(p => p.Length > 0)
                .Select(p => p.Trim())
                .Select(_converter) // Convert each string to T using the converter
                .ToArray();

            return await Task.FromResult(items);
        }

        private static T DefaultConverter(string s)
        {
            return (T)Convert.ChangeType(s, typeof(T));
        }
    }
}