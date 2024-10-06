from math import gcd

def lcm(x, y):
    return x * y // gcd(x, y)

def get_lcm(arr):
    lcm_value = arr[0]
    for i in arr[1:]:
        lcm_value = lcm(lcm_value, i)
    return lcm_value

def get_gcd(arr):
    gcd_value = arr[0]
    for i in arr[1:]:
        gcd_value = gcd(gcd_value, i)
    return gcd_value

def getTotalX(a, b):
    lcm_a = get_lcm(a)
    gcd_b = get_gcd(b)
    
    count = 0
    for i in range(lcm_a, gcd_b + 1, lcm_a):
        if gcd_b % i == 0:
            count += 1
    return count