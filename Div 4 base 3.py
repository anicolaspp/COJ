n = raw_input()
sum = 0
for i in range(len(n)):
    if i % 2 == 0:
        sum += i
    else:
        sum -= i

if sum % 4 == 0:
    print "YES"
else:
    print "NO"