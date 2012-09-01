
def Rev(x):
    result = ""
    i = len(x) - 1
    while i >= 0:
        result += x[i]
        i -=1

    return result

def S(x, y, p, r):

    for i in range(len(x)):
        if x[i] == "0" and y[i] == "0":
            if p == "0":
                r[i] = "0"
            else:
                r[i] = "1"
                p = "0"
        else:
             if x[i] == "1" and y[i] == "1":
                 if p == "0":
                     r[i] = "0"
                     p = "1"
                 else:
                     r[i] = "1"
             else:
                 if p == "0":
                     r[i] = "1"
                 else:
                     r[i] = "0"
                     p = "1"

    if p == "1":
        r.append(p)
    return r

def C(x):
    c = 0;
    for i in x:
        if i == "1":
            c += 1
    return c

def Zero(n):
    result = []
    for i in range(n):
        result.append("0")
    return result


line = raw_input().split(" ")
N = int(line[0])
L = int(line[1])
l = int(line[2])
count = 1

x = Zero(N)
y = Zero(N - 1)
y.insert(0, "1")
result = Zero(N)

while count < l:
    x = S(x, y, "0", result)
    result = Zero(N)
    if C(x) <= L:
        count += 1

print Rev(x)
