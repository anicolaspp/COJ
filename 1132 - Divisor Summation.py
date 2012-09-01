
import math

t = int(raw_input())
for i in range(t):
    n = int(raw_input())
    result = 0
    for j in range(1, (n / 2) + 1):
        if n % j == 0:
            result += j
    print result