using Lab1;

string input = File.ReadAllText("INPUT.TXT").Trim();
int[] parts = input.Split(' ').Select(int.Parse).ToArray();

int a = parts[0];
int b = parts[1];
int c = parts[2];

PermutationSolver.Solve(a, b, c);