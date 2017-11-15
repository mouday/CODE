# 双冒号::
# 1、表示常量
# 2、命名空间
class Fruit
    class Apple
        COLOR = "red"
    end
end

puts Fruit::Apple::COLOR

# api
# ::类方法
# #实例方法
# ？结尾，返回布尔值

#代码块
# block,proc,lambda,默认最后一行有返回值
#不能出现return

# {} 与 do...end 几乎一样
[1,2,3].each {|e| puts e}

[1,2,3].each do |e|
    puts e
end

result = [1,2,3].map do |e|
    e*e
end
puts result.inspect

result = [1,2,3].map do |e|
    "#{e}#{e}"
end
puts result
Student.all.map{ |student|
    {
        :name => student.name,
        :age =>student.age
    }
}

give "我",:what =>"咖啡", :count => "2", :unit =>"杯" do
    "味道不错呦"
end

# 三个参数：
# give( "我",#string
#     {:what =>"咖啡", :count => "2", :unit =>"杯"},#hash
#     do "味道不错呦" end #block
# )