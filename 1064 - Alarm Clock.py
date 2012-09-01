


while True:
    line = raw_input().split(" ")
    h1 = int(str(line[0]))
    m1 = int(str(line[1]))
    h2 = int(str(line[2]))
    m2 = int(str(line[3]))

    if h1 == 0 and h2 == 0 and m1 == 0 and m2 == 0:
        break;

    if h1 == 0:
        h1 = 24
    if h2 == 0:
        h2 = 24

    x = ((h1 * 60 + m1) - (h2 * 60 + m2))
    if x > 0:
        y = (23 - abs(h1 - h2))
        x = (y * 60) + abs(((h2 - 1) * 60 + m1) - (h2 * 60 + m2))

    print abs(x)