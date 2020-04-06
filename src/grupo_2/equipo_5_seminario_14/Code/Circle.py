class Circle:
    def __init__(self, radius):
        self._radius = radius

    @property
    def radius(self):
        return self._radius

    @radius.setter
    def radius(self, value):
        if value >= 0:
            self._radius = value
        else:
            raise ValueError("Radius must be positive")

    @property
    def area(self):
        return self.pi() * self.radius ** 2

    def cylinder_volume(self, height):
        return self.area * height

    @classmethod
    def unit_circle(cls):
        return cls(1)

    @staticmethod
    def pi():
        return 3.1415926535


c = Circle(5)
c.radius
c.area
c.radius = 2
c.area

#AttributeError: can't set attribute
c.area = 100

c.cylinder_volume(height=4)

#ValueError: Radius must be positive
c.radius = -1

c = Circle.unit_circle()
c.radius
c.pi()
Circle.pi()
