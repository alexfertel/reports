from functionTools import _, fixParams


def f(a, b, c, d=2):
    print(a, b, c, d)


f = fixParams(f, 6, _, _, d=22)
f(1, 3)
