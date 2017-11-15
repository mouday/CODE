class Apple
    #类方法,self
    def Apple.name
        "apple"
    end

    #实例方法
    def color
        "red"
    end
end

puts Apple.new.color
puts Apple.name