<?php
interface iCoffee
{
	public function getBaseCost();
}

class Coffee implements iCoffee
{
	protected $_baseCost = 0;
	
	public function getBaseCost()
	{
		return $this->_baseCost;
	}
}

class BlackCoffee extends Coffee
{
	public function __construct()
	{
		$this->_baseCost = 5;
	}
}

abstract class CoffeeDecorator implements iCoffee
{
	protected $_coffee;
	
	public function __construct(iCoffee $Coffee)
	{
		$this->_coffee = $Coffee;
	}
}

class WithCream extends CoffeeDecorator
{
	public function getBaseCost()
	{
		return $this->_coffee->getBaseCost() + 1.5;
	}
}

class WithMilk extends CoffeeDecorator
{
	public function getBaseCost()
	{
		return $this->_coffee->getBaseCost() + 4;
	}
}

class WithChocolate extends CoffeeDecorator
{
	public function getBaseCost()
	{
		return $this->_coffee->getBaseCost() + 5;
	}
}

$coffee = new WithChocolate(new WithMilk(new WithCream(new BlackCoffee())));
echo 'El precio del cafe es: $' . $coffee->getBaseCost();