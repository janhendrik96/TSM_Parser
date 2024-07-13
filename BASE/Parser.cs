using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kindle.IntegrationUtilities.RMB
{
    public class Parser : IDisposable
    {
        private StreamReader _reader;
        private StatementParser _statementParser;

        public Parser(string path)
        {
            _reader = new StreamReader(path);
            _statementParser = new StatementParser(_reader);
        }

        public Parser(Stream stream)
        {
            _reader = new StreamReader(stream);
            _statementParser = new StatementParser(_reader);
        }

        public IEnumerable<Statement> Parse()
        {
            while (!_reader.EndOfStream)
            {
                var statement = _statementParser.ReadStatement();

                if (statement != null)
                {
                    yield return statement;
                }
            }
        }

        public void Dispose()
        {
            _reader?.Dispose();
        }
    }
}
