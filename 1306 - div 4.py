
t = int(raw_input())
for i in range(t):
    line = raw_input()
    line = line[len(line) - 2] + line[len(line) - 1]
    line = int(line)
    if line % 4 == 0:
        print "YES"
    else:
        print "NO"