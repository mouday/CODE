# Mixed in:一种代码重用的形式
# interface implementation
require "./tool.rb"

class Student
    include Tool#继承Tool
end

puts Student.new.show_tip() #=> this is the tip

class Teacher
    include Tool
end

puts Teacher.new.show_tip()