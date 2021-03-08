from typing import List, Dict, get_type_hints

primes: List[int] = []
word: str
MyDict: Dict[str, int] = {}
primes.append('a')
print(primes[0])


import __main__
print (get_type_hints(__main__))