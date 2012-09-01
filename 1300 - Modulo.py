
count = 0
res = []

for i in range(42):
    res.append(False);

for i in range(10):
    x = int(raw_input())
    mod = x % 42
    if res[mod] == False:
        count += 1
        res[mod] = True

print count