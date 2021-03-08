import time
from tqdm import tqdm
import random

# Python Quick Sort
def partition(arr,low,high): 
    i = (low-1)         # index of smaller element 
    pivot = arr[high]     # pivot 
  
    for j in range(low , high): 
        # If current element is smaller than or 
        # equal to pivot 
        if   arr[j] <= pivot: 
            # increment index of smaller element 
            i = i+1 
            arr[i],arr[j] = arr[j],arr[i] 
    arr[i+1],arr[high] = arr[high],arr[i+1] 
    return ( i+1 )


def quickSort(arr,low,high): 
    if low < high: 
        # pi is partitioning index, arr[p] is now 
        # at right place 
        pi = partition(arr,low,high) 
        # Separately sort elements before 
        # partition and after partition 
        quickSort(arr, low, pi-1) 
        quickSort(arr, pi+1, high)


def bubbleSort(arr):
    for i in range(len(arr)):
        for j in range(len(arr)):
            if arr[i] < arr[j]:
                arr[i], arr[j] = arr[j], arr[i]
    
    return arr


# Fibonacci
def fib(a):
    if a == 1:
        return 0
    elif a == 2:
        return 1
    else:
        return fib(a-1) + fib(a-2)


avg = []

# BubbleSort Test
for _ in tqdm(range(30)):
    a = [random.randint(1, 10000) for i in range(10000)]
    start = time.time()
    bubbleSort(a)
    end = time.time()
    avg.append(end - start)


# QuickSort Test
# for _ in tqdm(range(30)):
#     a = [random.randint(1, 1000000) for i in range(1000000)]
#     start = time.time()
#     quickSort(a, 0, 99999)
#     end = time.time()
#     avg.append(end - start)


# Fibonacci test
# for _ in tqdm(range(30)):
#     start = time.time()
#     fib(35)
#     end = time.time()
#     avg.append(end - start)

print("Operación realizada en:", sum(avg)/len(avg))
