def partition(arr, first, last)
  # first select one element from the list, can be any element. 
  # rearrange the list so all elements less than pivot are left of it, elements greater than pivot are right of it.
  pivot = arr[last]
  p_index = first
  
  i = first
  while i < last
    if arr[i] <= pivot
      temp = arr[i]
      arr[i] = arr[p_index]
      arr[p_index] = temp
      p_index += 1
    end
    i += 1
  end
  temp = arr[p_index]
  arr[p_index] = pivot
  arr[last] = temp
  return p_index
end

def quicksort(arr, first, last)
  if first < last
    p_index = partition(arr, first, last)
    quicksort(arr, first, p_index - 1)
    quicksort(arr, p_index + 1, last)
  end

  arr
end

def bubbleSort(arr)
    for i in 0..arr.length-1 do
        for j in 0..arr.length-1 do
            if arr[i] < arr[j]
                arr[i], arr[j] = arr[j], arr[i]
            end
        end
    end
    arr
end


def fibonacci(a)
    if a == 1
        return 0
    end
    if a == 2
        return 1
    end
    return fibonacci(a - 1) + fibonacci(a - 2)
end

# avg = []

# Test quickSort
# for i in 1..35 do
#     arr = Array.new(10000) {rand(1..10000)}
#     starting = Process.clock_gettime(Process::CLOCK_MONOTONIC)
#     bubbleSort(arr)
#     ending = Process.clock_gettime(Process::CLOCK_MONOTONIC)
#     puts(ending - starting)
#     avg.append(ending - starting)
# end


# Test BubbleSort
# for i in 1..35 do
#     arr = Array.new(1000000) {rand(1..1000000)}
#     starting = Process.clock_gettime(Process::CLOCK_MONOTONIC)
#     quicksort(arr, 0, 999999)
#     ending = Process.clock_gettime(Process::CLOCK_MONOTONIC)
#     # puts(ending - starting)
#     avg.append(ending - starting)
# end

# Test Fibonacci
# for i in 1..35 do
#     starting = Process.clock_gettime(Process::CLOCK_MONOTONIC)
#     fibonacci(35)
#     ending = Process.clock_gettime(Process::CLOCK_MONOTONIC)
#     # puts(ending - starting)
#     avg.append(ending - starting)
# end

# puts avg.sum / avg.length