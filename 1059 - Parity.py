
def P(x):
    s = ""
    for i in x:
        s += str(i)
    return s

while 1:
    x = int(raw_input())

    if x == 0:
        exit()

    l = []
    result = 0;
    while x >= 2:
        mod = x % 2
        l.insert(0, mod)
        if mod != 0:
            result += 1
        x = x / 2

    l.insert(0, x)
    result += x
    print "The parity of",
    print P(l),
    print "is " + str(result) + " (mod 2)."
