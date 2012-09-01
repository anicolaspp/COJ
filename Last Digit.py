def f(n, x, y):
	r = x
	for i in range(y + 1, n + 1):
		r *= i
	return r

while True:
    try:
        x = dict()
        line = raw_input()
        m = [1, 1]
        for i in line:
            if x.__contains__(i):
                x[i][0] *= (x[i][1] + 1)
                x[i][1] += 1
                if x[i][0] > m[0]:
                    m[0] = x[i][0]
                    m[1] = x[i][1]
            else:
                x[i] = [1, 1]

        n = f(len(line), m[0], m[1])
        d = 1

        for i in x.items():
            d = d * i[1][0]

        print (n / d) % 10

    except:
        break;