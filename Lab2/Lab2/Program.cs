using Lab2;

string[] lines = File.ReadAllLines("INPUT.TXT");
string xi = lines[0];
string eta = lines[1];

(string alpha, string beta) = LongestCommonSubstringFinder.FindLongestCommonSubstring(xi, eta);

using var writer = new StreamWriter("OUTPUT.TXT");
writer.WriteLine(alpha);
writer.WriteLine(beta);