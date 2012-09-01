

t = int(raw_input())
for i in range(t):
    line = raw_input().split(" ")
    x = int(line[0]) + int(line[1])
    y = int(line[2])

    count = 0
    while x >= y:
        x = (x - y) + 1
        count += 1

    print count