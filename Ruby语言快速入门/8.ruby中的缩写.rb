# ruby中的缩写.
# 1、方法调用的最外层括号可省略
puts("helloworld")
puts "helloworld"

#2、函数最后一行默认有return
def color
    "red"  #return "color"
end

# 3、hash最外面的{}在大多数情况下可以省略
Apple.create :name =>"apple", :"color" => "red"
# 等同于：
# Apple.create({:name =>"apple", :"color" => "red"})
# 等同于：
# Apple.create name: "apple", color: "red"

# 4、调用block中的方法
Apple.all.map{|apple| apple.name}
# #等同于
# Apple.all.map(&:name)
