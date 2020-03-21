//C++17
//If/Switch

auto val = GetValue();
if (condition(val))
  //on success
else
  //On false…


/////////////////////////////

if(auto val = GetValue(); condition(val))
	//on success
else
  //on false…

//////////////////////////////////////


switch (initial-statement; variable) {
  //....
  // cases
}

////////////////////////////////////

const std::string myString = "My Hello World";

const auto it = myString.find("Hello");
if (it != std::string::npos)
   					 std::cout << it << " Hello\n";

const auto it2 = myString.find("World");
if (it2 != std::string::npos)
    			std::cout << it2 << " World\n";


///////////////////////////////////////////////////////

if (const auto it = myString.find("Hello"); it != std::string::npos)
  std::cout << it << " Hello\n";
else
  std::cout << it << " not found!!\n";

//////////////////////////////////////////////////////

switch (int i = rand() % 100; i) {
  default:
    			std::cout << "i = " << i << "\n"; break;
}
/////////////////////////////////////////////////////////////




/////////////////////////////////////////////////////////
//Template Arg Deduction

std::pair<int,double> myPair(10, 0.0);


////////////////////////////////////////////

auto myPair = std::make_pair(10, 0.0);

//////////////////////////////////////////////////////

std::pair myPair(10, 0.0);

/////////////////////////////////////////////////////////

template<class T>
int Function(T object);


/////////////////////////////////////////////////

int result = Function<float>(100.f);

//////////////////////////////////////////////

int result = Function(100.f);

/////////////////////////////////////////////////


template<class T, T* object>
int Function();

/////////////////////////////////////////////

static float val = 100.f;
// …
int result = Function<float, &val>();

//////////////////////////////////////////////////

template<typename Iterator>
void func(Iterator first, Iterator last){
	vector v(first, last);
}

//////////////////////////////////////////////

std::vector

typename std::iterator_traits<Iterator>::value_type .


/////////////////////////////////////////////////////////

template<typename Iterator> vector(Iterator b, Iterator e) -> vector< typename std :: iterator_traits<Iterator>::value_type >;


////////////////////////////////////////////////////////////////////////////


template<typename T>
returnType function(paramType param);

//////////////////////////////////////////////

function(expression);

///////////////////////////////////


////////////////////////////////////
//Otras Propuestas

template<typename... Args>
auto SumWithOne(Args... args){
	return(1 + ... + args);
}

////////////////////////////////////


constexpr auto ID = [](int n){ return n;};
constexpr int I = ID(3);
static_assert (I == 3);

constexpr int AddEleven(int n){
	return [n]{ return n + 11;}();
}

///////////////////////////////////


int a = 0;
double b = 0.0;
long c = 0;
std::tie(a,b,c) = tuple


//////////////////////////////////

auto[a, b, c] = tuple;
